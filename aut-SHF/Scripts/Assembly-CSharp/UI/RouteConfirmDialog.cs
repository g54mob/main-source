using UnityEngine;

namespace UI
{
	public class RouteConfirmDialog : BaseDialog
	{
		[SerializeField]
		private RectTransform parent;

		[SerializeField]
		private RectTransform guidePallet;

		[SerializeField]
		private RouteEnemyInfo routeEnemyInfo;

		[SerializeField]
		private RouteOrdeal routeOrdeal;

		private Vector3 _initialGuidePosition;

		private ChoiceRouteView _referenceRoute;

		private int _openDivision;

		public override void Init()
		{
		}

		public override void Open()
		{
		}

		private void AddRouteEnemyInfoTips()
		{
		}

		private void GuidePalletAnimation()
		{
		}

		public override void Back()
		{
		}

		public void OnNextOrdeal()
		{
		}

		public void OnHiddenOrdealInfo()
		{
		}
	}
}
