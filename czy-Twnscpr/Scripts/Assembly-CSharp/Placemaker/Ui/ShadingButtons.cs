using UnityEngine;
using UnityEngine.EventSystems;

namespace Placemaker.Ui
{
	public class ShadingButtons : UIBehaviour, UiMaster.IUiSetup
	{
		[SerializeField]
		private UiMaster master;

		[SerializeField]
		private RectTransform selector;

		[SerializeField]
		private BaseButton textureButton;

		[SerializeField]
		private BaseButton litButton;

		[SerializeField]
		private BaseButton lightButton;

		[SerializeField]
		private BaseButton stackButton;

		[SerializeField]
		private UpdateState texState;

		[SerializeField]
		private UpdateState litState;

		[SerializeField]
		private UpdateState lightState;

		[SerializeField]
		private UpdateState stackState;

		[SerializeField]
		private Vector4 shadingCurrent;

		[SerializeField]
		private Vector4 shadingTarget;

		[SerializeField]
		private bool isUpdating;

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		private void SubscribeButton(BaseButton button, UpdateState updateState)
		{
		}

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		public void Button_Texture()
		{
		}

		public void Button_Lit()
		{
		}

		public void Button_Light()
		{
		}

		public void Button_Stack()
		{
		}

		public void OnUpdate()
		{
		}

		public void SetShadingTarget(float tex, float light, float stack)
		{
		}

		private void StepNavigateHorizontal(Vector2 dir)
		{
		}
	}
}
