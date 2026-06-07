using System;
using System.Collections.Generic;
using UnityEngine;

namespace viperOSK
{
	public class OSK_MiniKeyboard : MonoBehaviour
	{
		public Vector2Int dimensions;

		public I_OSK_Key baseKey;

		private GameObject baseKeyGO;

		public GameObject keyPrefab;

		public Vector3 keySize;

		private List<List<I_OSK_Key>> keyLayout;

		public Sprite backgroundImg;

		public GameObject backgroundObj;

		private Vector3 center;

		private Vector3 size;

		private I_OSK_Key selectedKey;

		private Vector2Int selectedKeyLoc;

		private int numKeys;

		public bool isUI;

		public bool isJoystickSelection;

		public bool acceptGamePadInput;

		public Color highlighterColor;

		private float inputTimerThreshold;

		private float inputTimer;

		private bool AbtnDown;

		private bool isActive;

		private void Start()
		{
		}

		public Vector3 GetSize()
		{
			return default(Vector3);
		}

		public void Reset()
		{
		}

		public void SetBaseKey(GameObject base_key)
		{
		}

		public void Generate(List<string> chars, bool shiftup, Action<string, OSK_Receiver> callbackAction, bool bottomLeftOrder = true)
		{
		}

		private void CreateBackground()
		{
		}

		private void ResizeBackground()
		{
		}

		public void SelectedFirstKey()
		{
		}

		private void SelectedKeyMove(Vector2 dir)
		{
		}

		protected void InputFromPointerDevice()
		{
		}

		private void Update()
		{
		}
	}
}
