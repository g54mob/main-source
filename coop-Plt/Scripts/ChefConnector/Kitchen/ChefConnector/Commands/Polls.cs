using System;
using System.Collections.Generic;
using KitchenData;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen.ChefConnector.Commands
{
	public class Polls : GameSystemBase, IChefIntegration
	{
		private TwitchNameList System;

		private int RequestedNames;

		private bool RequestWipe;

		private bool RequestReshuffle;

		private EntityQuery ProgressOptions;

		private EntityQuery ActiveVotingOptions;

		private bool RequestPoll;

		private List<string> Cards = new List<string>();

		protected override void Initialise()
		{
			ProgressOptions = GetEntityQuery(new QueryHelper().All(typeof(CProgressionOption)).None(typeof(CPollRequested), typeof(CProgressionOption.Selected)));
			ActiveVotingOptions = GetEntityQuery(new QueryHelper().All(typeof(CProgressionOption), typeof(CPollRequested)).None(typeof(CProgressionOption.Selected)));
		}

		protected override void OnUpdate()
		{
			if (RequestPoll || ProgressOptions.IsEmpty)
			{
				return;
			}
			using NativeArray<CProgressionOption> nativeArray = ProgressOptions.ToComponentDataArray<CProgressionOption>(Allocator.Temp);
			using NativeArray<Entity> nativeArray2 = ProgressOptions.ToEntityArray(Allocator.Temp);
			if (nativeArray.Length != 2)
			{
				return;
			}
			Cards.Clear();
			for (int i = 0; i < nativeArray.Length; i++)
			{
				CProgressionOption cProgressionOption = nativeArray[i];
				Entity entity = nativeArray2[i];
				if (GameData.Main.TryGet<Unlock>(cProgressionOption.ID, out var output))
				{
					Cards.Add(output.Name);
				}
				base.EntityManager.AddComponentData(entity, new CPollRequested
				{
					Index = i
				});
			}
			RequestPoll = true;
		}

		public bool Handle(ChefCommandUpdate update)
		{
			if (update.Type != "POLL_UPDATE")
			{
				return false;
			}
			try
			{
				ChefPollUpdate chefPollUpdate = JsonUtility.FromJson<ChefPollUpdate>(update.Data);
				using NativeArray<CPollRequested> nativeArray = ActiveVotingOptions.ToComponentDataArray<CPollRequested>(Allocator.Temp);
				using NativeArray<Entity> nativeArray2 = ActiveVotingOptions.ToEntityArray(Allocator.Temp);
				for (int i = 0; i < nativeArray.Length; i++)
				{
					CPollRequested componentData = nativeArray[i];
					Entity entity = nativeArray2[i];
					if (componentData.Index >= 0 && componentData.Index <= chefPollUpdate.Choices.Count)
					{
						componentData.Votes = chefPollUpdate.Choices[componentData.Index];
						componentData.IsComplete = chefPollUpdate.IsComplete;
						componentData.IsForced = chefPollUpdate.IsForced;
						componentData.PollProgress = chefPollUpdate.Progress;
						base.EntityManager.SetComponentData(entity, componentData);
					}
				}
			}
			catch (Exception message)
			{
				Debug.LogWarning("[Chef Connector] Malformed data");
				Debug.LogWarning(message);
				return true;
			}
			return false;
		}

		public void SendMessages(Action<string> send)
		{
			if (RequestPoll)
			{
				send(JsonUtility.ToJson(new ChefPollRequest
				{
					Type = "POLLS",
					Instruction = "new",
					Cards = Cards
				}));
				RequestPoll = false;
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
