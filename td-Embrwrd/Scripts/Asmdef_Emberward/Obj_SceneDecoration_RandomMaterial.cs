using System;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Obj_SceneDecoration_RandomMaterial : Obj_SceneDecoration
{
	[Serializable]
	private class MatAndRendererPair
	{
		public Renderer renderer;

		public List<Material> list_materials;
	}

	[SerializeField]
	private List<MatAndRendererPair> matAndRendererPairs;

	private int randomIndex;

	private void Start()
	{
	}
}
