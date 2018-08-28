using UnityEngine;
using System.Collections;

public class Command{

	public virtual void execute(Receiver avator){}
	public virtual void undo(Receiver avator){}
}

//惨痛的教训：要new出来的类，千万不要继承Monobehaviour