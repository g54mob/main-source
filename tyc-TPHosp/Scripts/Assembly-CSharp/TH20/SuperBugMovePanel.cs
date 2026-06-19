using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class SuperBugMovePanel : SuperBugCreatorTabPanel
	{
		[SerializeField]
		private DynamicButton _upButton1;

		[SerializeField]
		private DynamicButton _upButton2;

		[SerializeField]
		private DynamicButton _upButton3;

		[SerializeField]
		private DynamicButton _downButton1;

		[SerializeField]
		private DynamicButton _downButton2;

		[SerializeField]
		private DynamicButton _downButton3;

		[SerializeField]
		private DynamicButton _leftButton1;

		[SerializeField]
		private DynamicButton _leftButton2;

		[SerializeField]
		private DynamicButton _leftButton3;

		[SerializeField]
		private DynamicButton _rightButton1;

		[SerializeField]
		private DynamicButton _rightButton2;

		[SerializeField]
		private DynamicButton _rightButton3;

		[SerializeField]
		private Image _nodeIcon;

		[SerializeField]
		private float _lightNudge = 20f;

		[SerializeField]
		private float _mediumNudge = 80f;

		[SerializeField]
		private float _heavyNudge = 200f;

		protected override void Start()
		{
			base.Start();
			_upButton1.onPrimaryDown.AddListener(OnUpPressedLight);
			_upButton2.onPrimaryDown.AddListener(OnUpPressedMedium);
			_upButton3.onPrimaryDown.AddListener(OnUpPressedHeavy);
			_downButton1.onPrimaryDown.AddListener(OnDownPressedLight);
			_downButton2.onPrimaryDown.AddListener(OnDownPressedMedium);
			_downButton3.onPrimaryDown.AddListener(OnDownPressedHeavy);
			_leftButton1.onPrimaryDown.AddListener(OnLeftPressedLight);
			_leftButton2.onPrimaryDown.AddListener(OnLeftPressedMedium);
			_leftButton3.onPrimaryDown.AddListener(OnLeftPressedHeavy);
			_rightButton1.onPrimaryDown.AddListener(OnRightPressedLight);
			_rightButton2.onPrimaryDown.AddListener(OnRightPressedMedium);
			_rightButton3.onPrimaryDown.AddListener(OnRightPressedHeavy);
		}

		protected override void OnDestroy()
		{
			_upButton1.onPrimaryDown.RemoveListener(OnUpPressedLight);
			_upButton2.onPrimaryDown.RemoveListener(OnUpPressedMedium);
			_upButton3.onPrimaryDown.RemoveListener(OnUpPressedHeavy);
			_downButton1.onPrimaryDown.RemoveListener(OnDownPressedLight);
			_downButton2.onPrimaryDown.RemoveListener(OnDownPressedMedium);
			_downButton3.onPrimaryDown.RemoveListener(OnDownPressedHeavy);
			_leftButton1.onPrimaryDown.RemoveListener(OnLeftPressedLight);
			_leftButton2.onPrimaryDown.RemoveListener(OnLeftPressedMedium);
			_leftButton3.onPrimaryDown.RemoveListener(OnLeftPressedHeavy);
			_rightButton1.onPrimaryDown.RemoveListener(OnRightPressedLight);
			_rightButton2.onPrimaryDown.RemoveListener(OnRightPressedMedium);
			_rightButton3.onPrimaryDown.RemoveListener(OnRightPressedHeavy);
			base.OnDestroy();
		}

		protected override void Refresh()
		{
			_nodeIcon.overrideSprite = SelectedNode?.Definition?.Icon;
		}

		private void OnUpPressedLight()
		{
			if (SelectedNode != null)
			{
				SelectedNode.Position += new Vector2(0f, _lightNudge);
				Refresh();
				OnDefinitionChanged.InvokeSafe();
			}
		}

		private void OnUpPressedMedium()
		{
			if (SelectedNode != null)
			{
				SelectedNode.Position += new Vector2(0f, _mediumNudge);
				Refresh();
				OnDefinitionChanged.InvokeSafe();
			}
		}

		private void OnUpPressedHeavy()
		{
			if (SelectedNode != null)
			{
				SelectedNode.Position += new Vector2(0f, _heavyNudge);
				Refresh();
				OnDefinitionChanged.InvokeSafe();
			}
		}

		private void OnDownPressedLight()
		{
			if (SelectedNode != null)
			{
				SelectedNode.Position += new Vector2(0f, 0f - _lightNudge);
				Refresh();
				OnDefinitionChanged.InvokeSafe();
			}
		}

		private void OnDownPressedMedium()
		{
			if (SelectedNode != null)
			{
				SelectedNode.Position += new Vector2(0f, 0f - _mediumNudge);
				Refresh();
				OnDefinitionChanged.InvokeSafe();
			}
		}

		private void OnDownPressedHeavy()
		{
			if (SelectedNode != null)
			{
				SelectedNode.Position += new Vector2(0f, 0f - _heavyNudge);
				Refresh();
				OnDefinitionChanged.InvokeSafe();
			}
		}

		private void OnLeftPressedLight()
		{
			if (SelectedNode != null)
			{
				SelectedNode.Position += new Vector2(0f - _lightNudge, 0f);
				Refresh();
				OnDefinitionChanged.InvokeSafe();
			}
		}

		private void OnLeftPressedMedium()
		{
			if (SelectedNode != null)
			{
				SelectedNode.Position += new Vector2(0f - _mediumNudge, 0f);
				Refresh();
				OnDefinitionChanged.InvokeSafe();
			}
		}

		private void OnLeftPressedHeavy()
		{
			if (SelectedNode != null)
			{
				SelectedNode.Position += new Vector2(0f - _heavyNudge, 0f);
				Refresh();
				OnDefinitionChanged.InvokeSafe();
			}
		}

		private void OnRightPressedLight()
		{
			if (SelectedNode != null)
			{
				SelectedNode.Position += new Vector2(_lightNudge, 0f);
				Refresh();
				OnDefinitionChanged.InvokeSafe();
			}
		}

		private void OnRightPressedMedium()
		{
			if (SelectedNode != null)
			{
				SelectedNode.Position += new Vector2(_mediumNudge, 0f);
				Refresh();
				OnDefinitionChanged.InvokeSafe();
			}
		}

		private void OnRightPressedHeavy()
		{
			if (SelectedNode != null)
			{
				SelectedNode.Position += new Vector2(_heavyNudge, 0f);
				Refresh();
				OnDefinitionChanged.InvokeSafe();
			}
		}
	}
}
