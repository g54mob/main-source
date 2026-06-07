using System;
using UnityEngine;

namespace FluffyUnderware.Curvy.Controllers
{
	[Serializable]
	public class OnPositionReachedSettings : ISerializationCallbackReceiver
	{
		public string Name;

		public CurvySplineMoveEvent Event;

		public float Position;

		public CurvyPositionMode PositionMode;

		public TriggeringDirections TriggeringDirections;

		public Color GizmoColor;

		[HideInInspector]
		[SerializeField]
		private bool initialized;

		private void InitializeFieldsWithDefaultValue()
		{
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}

		public OnPositionReachedSettings Clone()
		{
			return null;
		}
	}
}
