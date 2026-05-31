using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;
using LightJson;
using UnityEngine;

namespace Assets.Source.World
{
	public abstract class AutoWorker : IJsonSource
	{
		private class AutoWorkerConstructionProgress : ConstructionProgress
		{
			private AutoWorker _worker;

			public override string Name => "AutoWorker: " + _worker.Parent.DisplayName;

			public override Sprite Icon => _worker.Parent.Icon;

			public AutoWorkerConstructionProgress(AutoWorker parent)
			{
				_worker = parent;
			}

			public AutoWorkerConstructionProgress(AutoWorker parent, float time, IEnumerable<KeyValuePair<ItemType, int>> materials)
				: base(time, materials)
			{
				_worker = parent;
			}

			public override bool CanProceedConstruction()
			{
				return _worker.Parent.Construction == null;
			}

			protected override void OnConstructionCompleted()
			{
				_worker.Construction = null;
				_worker.Parent.ActiveFrame?.UpdateAutoWorker(_worker.Slot);
			}

			protected override void OnConstructionCanceled()
			{
				_worker.Parent.RemoveAutoWorker(_worker);
			}
		}

		public readonly WorldFrame Parent;

		public readonly WorldAnchor Slot;

		protected float _baseConstructionTime = 1f;

		public ConstructionProgress Construction { get; private set; }

		public bool UnderConstruction => Construction != null;

		public AutoWorker(WorldFrame parent, WorldAnchor slot)
		{
			Parent = parent;
			Slot = slot;
		}

		public void Update(float delta)
		{
			if (Construction == null)
			{
				ActiveUpdate(delta);
			}
		}

		public virtual void StartConstruction(IEnumerable<KeyValuePair<ItemType, int>> materials)
		{
			Construction = new AutoWorkerConstructionProgress(this, _baseConstructionTime, materials);
			GamePlayer.Current.AddConstruction(Construction);
		}

		public void CancelConstruction()
		{
			Construction?.Cancel();
		}

		public abstract void ActiveUpdate(float delta);

		public abstract void SetupActiveFrame(ActiveWorldFrame frame);

		public abstract void LoadFromJson(JsonValue val);

		public virtual JsonValue ToJson()
		{
			JsonObject jsonObject = new JsonObject { { "Slot", Slot.Slot } };
			if (Construction != null)
			{
				jsonObject["Construction"] = Construction.ToJson();
			}
			return jsonObject;
		}

		public static AutoWorker FromJson(WorldFrame parent, JsonValue val)
		{
			AutoWorker autoWorker = parent.CreateAutoWorker(new WorldAnchor(WorldAnchorType.AutoWorker, val["Slot"]));
			if (val.AsJsonObject.ContainsKey("Construction"))
			{
				AutoWorkerConstructionProgress autoWorkerConstructionProgress = new AutoWorkerConstructionProgress(autoWorker);
				autoWorker.Construction = ConstructionProgress.FromJson(val["Construction"], autoWorkerConstructionProgress);
				GamePlayer.Current.AddConstruction(autoWorkerConstructionProgress);
			}
			autoWorker.LoadFromJson(val);
			return autoWorker;
		}
	}
}
