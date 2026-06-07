using LightJson;
using UnityEngine;

namespace Assets.Source.World
{
	public class ClickerCrafter : ManualCrafter
	{
		private bool _consumeNext = true;

		private UIProgressBar _progress;

		public ClickerCrafter(CraftingFrame parent, WorldAnchor slot)
			: base(parent, slot)
		{
		}

		public override void Start()
		{
			base.TimeRequired = base.Parent.GetCraftingTime(handCraft: true);
			if (_consumeNext)
			{
				if (!InitStartCrafting())
				{
					return;
				}
				_consumeNext = false;
			}
			base.TimeAccumulated += base.Parent.TimePerClick;
			if (!_progress)
			{
				_setupProgress();
			}
			float progress = Mathf.Clamp01(base.TimeAccumulated / base.TimeRequired);
			base.Parent.ActiveFrame?.TriggerGizmoClick(Slot, progress);
			_progress.UpdateProgress(progress);
			if (base.TimeAccumulated >= base.TimeRequired)
			{
				base.TimeAccumulated -= base.TimeRequired;
				_consumeNext = true;
				DoCraftingResult();
				_progress.ResetProgress();
			}
		}

		private void _setupProgress()
		{
			if ((bool)_progress)
			{
				Object.Destroy(_progress.gameObject);
			}
			if (base.TimeAccumulated > 0f)
			{
				_progress = base.Parent.ActiveFrame?.ShowProgress(Slot, 0f);
			}
		}

		public override void ActiveUpdate(float delta)
		{
		}

		public override void SetupActiveFrame(ActiveWorldFrame frame)
		{
			_setupProgress();
		}

		public override void LoadFromJson(JsonValue val)
		{
			base.LoadFromJson(val);
			_consumeNext = val["ConsumeNext"];
		}

		public override JsonValue ToJson()
		{
			JsonObject jsonObject = base.ToJson();
			jsonObject["ConsumeNext"] = _consumeNext;
			return jsonObject;
		}
	}
}
