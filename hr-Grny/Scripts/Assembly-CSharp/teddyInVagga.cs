using System;
using UnityEngine;

[Serializable]
public class teddyInVagga : MonoBehaviour
{
	public GameObject slendrina;

	public GameObject teddyTexture;

	public GameObject gameController;

	public GameObject granny;

	public bool fadeDown;

	public Shader shader1;

	public Renderer rend;

	public Transform GrannyStartPos;

	public GameObject glow;

	public virtual void Start()
	{
	}

	public virtual void OnTriggerEnter(Collider other)
	{
	}

	public virtual void Update()
	{
	}
}
