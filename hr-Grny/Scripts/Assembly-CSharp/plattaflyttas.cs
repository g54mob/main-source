using System;
using UnityEngine;

[Serializable]
public class plattaflyttas : MonoBehaviour
{
	public bool Upp;

	public bool H;

	public bool Ner;

	public bool V;

	public AudioClip flyttaPlatta;

	public virtual void update()
	{
	}

	public virtual void MovePlatta()
	{
	}
}
