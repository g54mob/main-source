using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.UI
{
	public class ButtonNavigator : MonoBehaviour
	{
		public SelectableUI.SelectableType SelectionType;

		[SerializeField]
		private List<GameObject> _Graphics;

		private RectTransform rectTransform;

		private RectTransform OriginalParent;

		private RectTransform Target;

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void LateUpdate()
		{
		}

		private void Reset(RectTransform rtrans)
		{
		}

		private void MoveToSelection(RectTransform rtrans)
		{
		}

		private void SetVisibility(bool b)
		{
		}

		private void Disable(RectTransform rTrans)
		{
		}

		public void DisableAllNavigation()
		{
		}
	}
}
