using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class UI_PanelSetup : MonoBehaviour
	{
		[InfoBox("Don't forget to set the height fo the spawned object", EInfoBoxType.Normal)]
		[Foldout("Dev")]
		[SerializeField]
		private GameObject _sliderPrefab;

		[Foldout("Dev")]
		[SerializeField]
		private GameObject _togglePrefab;

		[Foldout("Dev")]
		[SerializeField]
		private GameObject _roulettePrefab;

		[Foldout("Dev")]
		[SerializeField]
		private GameObject _popUpPrefab;

		[Foldout("Dev")]
		[Required("Put the 'content' element of the scrollView here")]
		[SerializeField]
		private Transform _panelContent;
	}
}
