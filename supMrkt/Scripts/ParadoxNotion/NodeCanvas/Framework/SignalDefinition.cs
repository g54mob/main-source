using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ParadoxNotion;
using UnityEngine;

namespace NodeCanvas.Framework
{
	[CreateAssetMenu(menuName = "ParadoxNotion/CanvasCore/Signal Definition")]
	public class SignalDefinition : ScriptableObject
	{
		public delegate void InvokeArguments(Transform sender, Transform receiver, bool isGlobal, params object[] args);

		[SerializeField]
		[HideInInspector]
		private List<DynamicParameterDefinition> _parameters;

		public List<DynamicParameterDefinition> parameters
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public event InvokeArguments onInvoke
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void Invoke(Transform sender, Transform receiver, bool isGlobal, params object[] args)
		{
		}

		public void AddParameter(string name, Type type)
		{
		}

		public void RemoveParameter(string name)
		{
		}
	}
}
