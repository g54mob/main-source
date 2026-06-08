using DG.Tweening;
using UnityEngine;

namespace Dorfromantik
{
	public class TutorialEvent_HighlightTileSlot : TutorialEvent
	{
		private sealed class _003C_003Ec__DisplayClass9_0
		{
			public TutorialEvent_HighlightTileSlot _003C_003E4__this;

			public MeshRenderer meshRenderer;

			internal float _003CBegin_003Eb__0()
			{
				return meshRenderer.material.GetFloat(_003C_003E4__this.parameterName);
			}

			internal void _003CBegin_003Eb__1(float value)
			{
				meshRenderer.material.SetFloat(_003C_003E4__this.parameterName, value);
			}
		}

		[SerializeField]
		private TileSlotHighlighter tileSlotHighlighterPrefab;

		[SerializeField]
		private bool animateParameter;

		[SerializeField]
		private string parameterName;

		[SerializeField]
		private float animationDuration;

		[SerializeField]
		private float targetValue;

		[SerializeField]
		private InputRouter inputRouter;

		[SerializeField]
		private TileSlot target;

		private TileSlotHighlighter activeTileSlotHighlighter;

		public void SetTarget(TileSlot newTarget)
		{
			target = newTarget;
		}

		public override void Begin()
		{
			_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass9_0();
			CS_0024_003C_003E8__locals6._003C_003E4__this = this;
			inputRouter.OnMovePreviewTile += PreviewTileMoved;
			if (!activeTileSlotHighlighter)
			{
				activeTileSlotHighlighter = Object.Instantiate(tileSlotHighlighterPrefab, target.transform.position, Quaternion.identity, OverwritingSingleton<IngameUi>.Instance.world.transform);
			}
			else
			{
				activeTileSlotHighlighter.transform.position = target.transform.position;
				activeTileSlotHighlighter.Show(show: true);
			}
			if (animateParameter)
			{
				CS_0024_003C_003E8__locals6.meshRenderer = activeTileSlotHighlighter.GetComponentInChildren<MeshRenderer>();
				TweenSettingsExtensions.SetEase(TweenSettingsExtensions.SetLoops(DOTween.To(() => CS_0024_003C_003E8__locals6.meshRenderer.material.GetFloat(CS_0024_003C_003E8__locals6._003C_003E4__this.parameterName), delegate(float value)
				{
					CS_0024_003C_003E8__locals6.meshRenderer.material.SetFloat(CS_0024_003C_003E8__locals6._003C_003E4__this.parameterName, value);
				}, targetValue, animationDuration), -1, LoopType.Yoyo), Ease.InOutSine);
			}
		}

		private void PreviewTileMoved(TileSlot newTileSlot)
		{
			activeTileSlotHighlighter.Show(!newTileSlot || newTileSlot != target);
		}

		public override void Finish()
		{
			activeTileSlotHighlighter.Show(show: false);
			inputRouter.OnMovePreviewTile -= PreviewTileMoved;
		}

		public override void Skip()
		{
		}
	}
}
