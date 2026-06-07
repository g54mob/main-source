using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public class MeshModifier : ScriptableObject, ISerializationCallbackReceiver
	{
		[Serializable]
		public class Modifier
		{
			[Tooltip("The name of the slot this modifier is applied to.")]
			public string SlotName;

			[Tooltip("The name of the DNA this modifier gets it's scale value from. Leave blank to manually set the scale.")]
			public string DNAName;

			[Tooltip("The scale value, can be set manually or from a DNA value.")]
			public float Scale;

			[Tooltip("This is the list of adjustments for the current slot.")]
			public VertexAdjustmentCollection adjustments;

			public string TemplateAdjustmentJSON;

			public string AdjustmentType;

			public string CollectionType;

			public List<string> JsonAdjustments;

			public void EditorInitialize(Type collectionType)
			{
			}

			public void BeforeSaving()
			{
			}

			public void AfterLoading()
			{
			}

			public UMAMeshData Process(UMAMeshData src)
			{
				return null;
			}

			public MeshDetails Process(MeshDetails src)
			{
				return null;
			}
		}

		public List<Modifier> modifiers;

		public List<Modifier> Modifiers
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}

		public MeshDetails Process(string Slot, MeshDetails Src)
		{
			return null;
		}
	}
}
