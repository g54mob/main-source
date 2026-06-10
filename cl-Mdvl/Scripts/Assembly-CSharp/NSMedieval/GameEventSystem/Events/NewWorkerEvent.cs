using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Tools;
using UnityEngine;

namespace NSMedieval.GameEventSystem.Events
{
	[Serializable]
	[FVSerializableKey("GameEvents.NewWorkerEvent", "")]
	public class NewWorkerEvent : GameEventInstance, IWorkerPhaseDataHolder
	{
		[SerializeField]
		protected HumanoidInstance workerToAdd;

		private string newWorkerName;

		private const string fvs_workerToAdd = "workerToAdd";

		public HumanoidInstance CachedWorkerToAdd { get; private set; }

		public HumanoidInstance HumanoidToAdd
		{
			get
			{
				return workerToAdd;
			}
			set
			{
				workerToAdd = value;
			}
		}

		public NewWorkerEvent()
		{
		}

		public void SetNewWorkerName(string newWorkerName)
		{
			this.newWorkerName = newWorkerName;
		}

		protected override GameEventPhaseBase GetStartingPhase()
		{
			workerToAdd = GenerateWorkerToAdd();
			return new ShowDialogPhaseBranching(0).NextPhaseOnAccept(new AddWorkerPhase()).NextPhaseOnReject(new DisposeWorkerToAddPhase());
		}

		public override bool CanStart()
		{
			if (!MonoSingleton<GlobalSaveController>.IsInstantiated())
			{
				return false;
			}
			if (base.CanStart())
			{
				return GlobalSaveController.CurrentVillageData.Workers.Count > 0;
			}
			return false;
		}

		protected HumanoidInstance GenerateWorkerToAdd()
		{
			GameEventInstance.Logger.Info("Generating worker to add");
			BodyType defaultBodyType = ((base.Blueprint.GenderDistribution == 0f || !(UnityEngine.Random.Range(0f, 1f) >= base.Blueprint.GenderDistribution)) ? BodyType.Male : BodyType.Female);
			List<SerializableIdValuePair> list = new List<SerializableIdValuePair>();
			foreach (Perk allItem in Repository<PerkRepository, Perk>.Instance.GetAllItems())
			{
				if (allItem.ForbidForNewSettler)
				{
					list.Add(new SerializableIdValuePair(allItem.GetID(), 0f));
				}
			}
			HumanoidInstance humanoidInstance = (CachedWorkerToAdd = MonoSingleton<WorkerGenerator>.Instance.GenerateWorker(defaultBodyType, list));
			if (!string.IsNullOrEmpty(newWorkerName))
			{
				humanoidInstance.Info.SetFirstName(newWorkerName);
			}
			return humanoidInstance;
		}

		public override string ProcessLocalizedButtonText(string buttonText)
		{
			return TextFormatting.FormatText(buttonText, HumanoidToAdd);
		}

		public override string GetEventTitle(GameEvent.DialogContent dialogContent)
		{
			return MonoSingleton<LocalizationController>.Instance.GetText(dialogContent.TypeTextKey, workerToAdd);
		}

		public override string GetEventName(GameEvent.DialogContent dialogContent, BodyType bodyType)
		{
			return MonoSingleton<LocalizationController>.Instance.GetText(dialogContent.NameTextKey, workerToAdd);
		}

		public override string GetEventInfo(GameEvent.DialogContent dialogContent)
		{
			return MonoSingleton<LocalizationController>.Instance.GetText(dialogContent.DescriptionTextKey, workerToAdd);
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("workerToAdd", workerToAdd);
		}

		public NewWorkerEvent(FVDeserializer deserializer)
			: base(deserializer)
		{
			workerToAdd = deserializer.ReadObject<HumanoidInstance>("workerToAdd");
			if (workerToAdd == null)
			{
				workerToAdd = deserializer.ReadObject<HumanoidInstance>("HumanoidToAdd");
			}
		}
	}
}
