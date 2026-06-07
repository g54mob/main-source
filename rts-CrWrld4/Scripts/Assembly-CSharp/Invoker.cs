using System.Collections;
using UnityEngine;

public class Invoker : MonoBehaviour
{
	public delegate void Function();

	public void InvokeNextFrame(Function function)
	{
	}

	private IEnumerator _InvokeNextFrame(Function function)
	{
		return null;
	}
}
