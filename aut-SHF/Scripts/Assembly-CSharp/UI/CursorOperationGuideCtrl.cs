using System.Collections.Generic;
using Libs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class CursorOperationGuideCtrl : SingletonMonoBehaviour<CursorOperationGuideCtrl>
	{
		[SerializeField]
		private TMP_Text text;

		[SerializeField]
		private Image image;

		private Transform imageTransform;

		private eMachine nowPalette;

		private eMachine nowMap;

		private eGuideCategory newGuideCategory;

		private eGuideCategory nowGuideCategory;

		private List<Rect> areaDb;

		private readonly int divide;

		private List<int> ueninigasuLine;

		private Dictionary<int, int> areaPair;

		private bool activeByCategory;

		private bool activeByGuideType;

		private Vector3 mousePosition;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void SetActive(bool? byCategory = null, bool? byGuideType = null)
		{
		}

		private void UpdateGuide()
		{
		}

		public void SetCursorMachineId(eMachine palette, eMachine map)
		{
		}

		public void SetPosition(Vector3 position)
		{
		}

		private void Update()
		{
		}

		private Vector3 GetAvoidCursorPosition(Vector3 vector3)
		{
			return default(Vector3);
		}

		private Vector3 GetFixCursorPosition()
		{
			return default(Vector3);
		}
	}
}
