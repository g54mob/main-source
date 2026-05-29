using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Placemaker.Ui
{
	public class Toucher : MonoBehaviour, UiMaster.IUiSetup
	{
		[Serializable]
		public class Tracker
		{
			[Serializable]
			public struct Data
			{
				public Vector2 delta;

				public Vector2 smoothDelta;

				public Vector2 pos;

				public Vector2 invYPos;

				public Vector2 smoothPos;

				public int frame;

				public float time;
			}

			public int id;

			public bool active;

			public Data startData;

			public Data lastData;

			public GameObject startHitObject;

			public bool draggable;

			public List<Data> datas;
		}

		public enum State
		{
			Idle = 0,
			Rotating = 1,
			Zooming = 2,
			Panning = 4,
			Pressing = 16,
			Dragging = 7,
			ZoomingAndPanning = 6
		}

		[SerializeField]
		private GraphicRaycaster graphicRaycaster;

		private GameObject draggableArea;

		private UiMaster master;

		private PointerEventData pointerEventData;

		public State state;

		public List<Tracker> trackers;

		public List<int> draggables;

		private int lastRotator;

		private float lastPanTime;

		private const float rotationMultiplier = 0.4f;

		private void EndRotation()
		{
		}

		private void LateUpdate()
		{
		}

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		public void OnGUI()
		{
		}
	}
}
