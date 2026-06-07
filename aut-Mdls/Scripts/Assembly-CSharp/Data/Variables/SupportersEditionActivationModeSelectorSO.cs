using UnityEngine;

namespace Data.Variables
{
	[CreateAssetMenu(menuName = "Variables/SupportersEditionActivationModeSelector", fileName = "SupportersEditionActivationModeSelector", order = 0)]
	public class SupportersEditionActivationModeSelectorSO : ScriptableObject
	{
		[SerializeField]
		private SupportersEditionActivationMode _supportersEditionActivationMode;

		public SupportersEditionActivationMode SupportersEditionActivationMode => _supportersEditionActivationMode;
	}
}
