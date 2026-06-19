using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class InspectorStaffInfoRow : MonoBehaviour
	{
		[SerializeField]
		private Image StaffIcon;

		[SerializeField]
		private TMP_Text StaffName;

		[SerializeField]
		private DynamicButton SelectButton;

		public void Setup(Sprite icon, string text, UnityAction OnPress)
		{
			StaffIcon.sprite = icon;
			StaffName.text = text;
			SelectButton.onPrimaryDown.RemoveAllListeners();
			SelectButton.onPrimaryDown.AddListener(OnPress);
		}
	}
}
