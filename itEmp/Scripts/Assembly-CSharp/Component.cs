using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Component
{
	public string name;

	public bool view;

	public MonoBehaviour component;

	[SerializeField]
	public List<Variable> Variables;
}
