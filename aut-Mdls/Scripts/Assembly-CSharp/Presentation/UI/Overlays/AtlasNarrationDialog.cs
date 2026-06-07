using Events.UI.Overlays;
using UnityEngine;

namespace Presentation.UI.Overlays
{
	public class AtlasNarrationDialog : NarrationDialog
	{
		private static readonly int AtlasAnimTalk = Animator.StringToHash("AtlasAnimTalk");

		private static readonly int AtlasAnimIdle = Animator.StringToHash("AtlasAnimIdle");

		private static readonly int AtlasTalkIndex = Animator.StringToHash("TalkIndex");

		private static readonly int Collapsed = Shader.PropertyToID("_Collapsed");

		[Header("Atlas specific")]
		[SerializeField]
		private GameObject _atlasScene;

		[SerializeField]
		private CollapsableNarration _collapsableNarration;

		[SerializeField]
		private Material _narratorMaterial;

		[SerializeField]
		private Camera _atlasCamera;

		[SerializeField]
		private Animator _atlasAnimator;

		protected override void Initialize()
		{
			base.Initialize();
			_collapsableNarration.OnCollapseStateChanged += SetCollapsedState;
		}

		protected override void UnInitialize()
		{
			base.UnInitialize();
			_collapsableNarration.OnCollapseStateChanged -= SetCollapsedState;
			SetCollapsedState(activated: false);
		}

		private void SetCollapsedState(bool activated)
		{
			_narratorMaterial.SetFloat(Collapsed, activated ? 1f : 0f);
		}

		protected override void StartNarrationAnim()
		{
			base.StartNarrationAnim();
			SetCollapsedState(activated: false);
			_atlasCamera.enabled = true;
			_atlasScene.SetActive(value: true);
			_atlasAnimator.SetInteger(AtlasTalkIndex, Random.Range(0, 4));
			_atlasAnimator.SetTrigger(AtlasAnimTalk);
			_audioManagerLocator?.AudioManager.StartAtlasTalkLoop();
		}

		protected override void EndNarrationAnim()
		{
			base.EndNarrationAnim();
			_atlasAnimator.SetTrigger(AtlasAnimIdle);
		}

		protected override void Hide()
		{
			_atlasCamera.enabled = false;
			_atlasScene.SetActive(value: false);
			base.Hide();
		}

		protected override bool CanShow(NarrationDto dto)
		{
			return dto.NarratorType == NarrationDto.Narrators.AtlasColony;
		}
	}
}
