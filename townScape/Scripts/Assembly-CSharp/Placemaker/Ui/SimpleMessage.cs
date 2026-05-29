using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Placemaker.Ui
{
	public class SimpleMessage : UIBehaviour, UiMaster.IUiSetup
	{
		[SerializeField]
		private TMP_Text text;

		[SerializeField]
		private UpdateState openState;

		[SerializeField]
		private float timer;

		[SerializeField]
		private Vector3 startPos;

		[SerializeField]
		private Color defaultColor;

		[SerializeField]
		private List<CornerImage> backgrounds;

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		public void SetParam(string param, string value)
		{
		}

		private void SetBackgroundColor(Color color)
		{
		}

		public void ShowMessage(string message, float time = 2f)
		{
		}

		public void ShowTerm(string message, float time = 2f)
		{
		}

		public void ShowTerm(string message, Color color, float time = 2f)
		{
		}

		protected override void OnEnable()
		{
		}

		public void Update()
		{
		}
	}
}
