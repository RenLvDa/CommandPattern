using UnityEngine;
using System.Collections;

public class Invoker : MonoBehaviour{

	Command command;
	//接收命令
	public void setCommand(Command command){
		this.command = command;
	}
	//执行命令
	public void action(Receiver avator){
		this.command.execute (avator);
	}
}

//ref 很关键，就算是引用类型也要加
