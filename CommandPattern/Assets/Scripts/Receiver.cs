using UnityEngine;
using System.Collections;

public class Receiver : MonoBehaviour {
	
	public void move(Vector3 T){
		transform.Translate (T);
	}
}
