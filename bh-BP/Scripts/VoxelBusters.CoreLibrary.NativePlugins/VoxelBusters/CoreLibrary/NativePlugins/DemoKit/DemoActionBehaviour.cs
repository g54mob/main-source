using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace VoxelBusters.CoreLibrary.NativePlugins.DemoKit
{
	public class DemoActionBehaviour<TActionType> : MonoBehaviour where TActionType : struct, IConvertible
	{
		[Serializable]
		public class SelectEvent : UnityEvent<Selectable>
		{
		}

		[SerializeField]
		private TActionType m_actionType;

		[SerializeField]
		[FormerlySerializedAs("onSelect")]
		private SelectEvent m_onSelect;

		public Selectable Selectable { get; private set; }

		public TActionType ActionType => default(TActionType);

		public SelectEvent OnSelect => null;

		private void Awake()
		{
		}

		private void RegisterForCallback(Selectable selectable)
		{
		}

		private void OnSelectInternal()
		{
		}
	}
}
