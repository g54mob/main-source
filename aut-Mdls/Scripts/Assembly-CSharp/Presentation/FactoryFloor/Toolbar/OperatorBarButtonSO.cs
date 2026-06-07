using System;
using UnityEngine;

namespace Presentation.FactoryFloor.Toolbar
{
	[Serializable]
	[CreateAssetMenu(menuName = "UI/Toolbar/OperatorBarButton", fileName = "OperatorBarButton", order = 0)]
	public class OperatorBarButtonSO : ScriptableObject
	{
		[SerializeField]
		private OperatorBarButton _operatorBarButtonPrefab;

		[SerializeField]
		private bool _partOfInputActionGroup;

		[SerializeField]
		private bool _isGroupStart;

		public OperatorBarButton Prefab => _operatorBarButtonPrefab;

		public bool PartOfInputActionGroup => _partOfInputActionGroup;

		public bool IsGroupStart => _isGroupStart;
	}
}
