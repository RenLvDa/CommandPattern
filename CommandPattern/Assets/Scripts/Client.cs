using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Client : MonoBehaviour {

	public Receiver avator;
	Stack<Command> commandStack;
	Command cmd;
	Invoker invoker;
	bool isRun = true;
	// Use this for initialization
	void Start () {
		avator = gameObject.GetComponent<Receiver> ();
		commandStack = new Stack<Command> ();
		invoker = new Invoker ();
	}
	
	// Update is called once per frame
	void Update () {
		cmd = Inputhander ();
		invoker.setCommand (cmd);
		if (isRun) {
			control ();
		} else {
			runCallBack ();
		}
	}

		
	void control(){
		if (cmd!=null) {
			commandStack.Push (cmd);
			invoker.action (avator);
		}
	}

	void runCallBack(){
		if (commandStack.Count > 0) {
			commandStack.Pop ().undo (avator);
		}
	}
		

	//切换到回放模式
	public void callBack(){
		isRun = false;
	}

	//切换到运行模式
	public void run(){
		isRun = true;
	}

	//根据输入获取操作命令
	Command Inputhander(){
		if (Input.GetKey (KeyCode.W)) {
			Debug.Log ("W");
			return new CommandMove (new Vector3 (0, 1, 0));
		}
		if (Input.GetKey (KeyCode.S)) {
			Debug.Log ("S");
			return new CommandMove (new Vector3 (0, -1, 0));
		}
		if (Input.GetKey (KeyCode.A)) {
			Debug.Log ("A");
			return new CommandMove (new Vector3 (-1, 0, 0));
		}
		if (Input.GetKey (KeyCode.D)) {
			Debug.Log ("D");
			return new CommandMove (new Vector3 (1, 0, 0));
		}
		return null;
	}
		
}
