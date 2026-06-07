using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.DevTools
{
	[HelpURL("https://curvyeditor.com/doclink/dtprefabpool")]
	[RequireComponent(typeof(PoolManager))]
	public class PrefabPool : UnityObjectPool<GameObject>
	{
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[SerializeField]
		private string m_Identifier;

		[SerializeField]
		private List<GameObject> m_Prefabs;

		public override string Identifier
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public List<GameObject> Prefabs
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected override void OnValidate()
		{
		}

		public void Initialize([NotNull] string identifier, PoolSettings settings, params GameObject[] prefabs)
		{
		}

		protected override GameObject CreateObject()
		{
			return null;
		}

		protected override GameObject GetItemGameObject(GameObject item)
		{
			return null;
		}
	}
}
