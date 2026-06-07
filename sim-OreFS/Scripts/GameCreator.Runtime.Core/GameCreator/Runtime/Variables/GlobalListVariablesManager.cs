using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[AddComponentMenu("")]
	public class GlobalListVariablesManager : Singleton<GlobalListVariablesManager>, IGameSave
	{
		[field: NonSerialized]
		private Dictionary<IdString, ListVariableRuntime> Values { get; set; }

		[field: NonSerialized]
		private HashSet<IdString> SaveValues { get; set; }

		public string SaveID => "global-list-variables";

		public LoadMode LoadMode => LoadMode.Greedy;

		public bool IsShared => false;

		public Type SaveType => typeof(SaveGroupListVariables);

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnSubsystemsInit()
		{
			Singleton<GlobalListVariablesManager>.Instance.WakeUp();
		}

		protected override void OnCreate()
		{
			base.OnCreate();
			Values = new Dictionary<IdString, ListVariableRuntime>();
			SaveValues = new HashSet<IdString>();
			GlobalListVariables[] listVariables = TRepository<VariablesRepository>.Get.Variables.ListVariables;
			foreach (GlobalListVariables globalListVariables in listVariables)
			{
				if (globalListVariables == null)
				{
					return;
				}
				Singleton<GlobalListVariablesManager>.Instance.RequireInit(globalListVariables);
			}
			SaveLoadManager.Subscribe(this);
		}

		public object Get(GlobalListVariables asset, IListGetPick pick, Args args)
		{
			int count = Count(asset);
			int index = pick?.GetIndex(count, args) ?? (-1);
			return Get(asset, index);
		}

		public object Get(GlobalListVariables asset, IListSetPick pick, Args args)
		{
			int count = Count(asset);
			int index = pick?.GetIndex(count, args) ?? (-1);
			return Get(asset, index);
		}

		public object Get(GlobalListVariables asset, int index)
		{
			if (!Values.TryGetValue(asset.UniqueID, out var value))
			{
				return null;
			}
			return value.Get(index);
		}

		public string Title(GlobalListVariables asset, int index)
		{
			if (!Values.TryGetValue(asset.UniqueID, out var value))
			{
				return string.Empty;
			}
			return value.Title(index);
		}

		public Texture Icon(GlobalListVariables asset, int index)
		{
			if (!Values.TryGetValue(asset.UniqueID, out var value))
			{
				return null;
			}
			return value.Icon(index);
		}

		public void Set(GlobalListVariables asset, IListSetPick pick, object value, Args args)
		{
			int count = Count(asset);
			if (Values.TryGetValue(asset.UniqueID, out var value2))
			{
				int index = pick?.GetIndex(value2, count, args) ?? 0;
				Set(asset, index, value);
			}
		}

		public void Set(GlobalListVariables asset, int index, object value)
		{
			if (Values.TryGetValue(asset.UniqueID, out var value2))
			{
				value2.Set(index, value);
				if (asset.Save)
				{
					SaveValues.Add(asset.UniqueID);
				}
			}
		}

		public void Insert(GlobalListVariables asset, IListGetPick pick, object value, Args args)
		{
			int count = Count(asset);
			int index = pick?.GetIndex(count, args) ?? 0;
			Insert(asset, index, value);
		}

		public void Insert(GlobalListVariables asset, int index, object value)
		{
			if (Values.TryGetValue(asset.UniqueID, out var value2))
			{
				value2.Insert(index, value);
				if (asset.Save)
				{
					SaveValues.Add(asset.UniqueID);
				}
			}
		}

		public void Push(GlobalListVariables asset, object value)
		{
			Insert(asset, Count(asset), value);
		}

		public void Remove(GlobalListVariables asset, IListGetPick pick, Args args)
		{
			int count = Count(asset);
			int index = pick?.GetIndex(count, args) ?? 0;
			Remove(asset, index);
		}

		public void Remove(GlobalListVariables asset, int index)
		{
			if (Values.TryGetValue(asset.UniqueID, out var value))
			{
				value.Remove(index);
				if (asset.Save)
				{
					SaveValues.Add(asset.UniqueID);
				}
			}
		}

		public void Clear(GlobalListVariables asset)
		{
			for (int num = Count(asset) - 1; num >= 0; num--)
			{
				Remove(asset, num);
			}
		}

		public void Move(GlobalListVariables asset, IListGetPick pickA, IListGetPick pickB, Args args)
		{
			int count = Count(asset);
			int source = pickA?.GetIndex(count, args) ?? 0;
			int destination = pickB?.GetIndex(count, args) ?? 0;
			Move(asset, source, destination);
		}

		public void Move(GlobalListVariables asset, int source, int destination)
		{
			if (Values.TryGetValue(asset.UniqueID, out var value))
			{
				value.Move(source, destination);
				if (asset.Save)
				{
					SaveValues.Add(asset.UniqueID);
				}
			}
		}

		public int Count(GlobalListVariables asset)
		{
			if (!Values.TryGetValue(asset.UniqueID, out var value))
			{
				return 0;
			}
			return value.Count;
		}

		public bool Contains(GlobalListVariables asset, object value)
		{
			if (!Values.TryGetValue(asset.UniqueID, out var value2))
			{
				return false;
			}
			int num = Count(asset);
			for (int i = 0; i < num; i++)
			{
				object obj = value2.Get(i);
				if (obj != null && obj == value)
				{
					return true;
				}
			}
			return false;
		}

		public void Register(GlobalListVariables asset, Action<ListVariableRuntime.Change, int> callback)
		{
			if (Values.TryGetValue(asset.UniqueID, out var value))
			{
				value.EventChange += callback;
			}
		}

		public void Unregister(GlobalListVariables asset, Action<ListVariableRuntime.Change, int> callback)
		{
			if (Values.TryGetValue(asset.UniqueID, out var value))
			{
				value.EventChange -= callback;
			}
		}

		private void RequireInit(GlobalListVariables asset)
		{
			if (!Values.ContainsKey(asset.UniqueID))
			{
				ListVariableRuntime listVariableRuntime = new ListVariableRuntime(asset.IndexList);
				listVariableRuntime.OnStartup();
				Values[asset.UniqueID] = listVariableRuntime;
			}
		}

		public object GetSaveData(bool includeNonSavable)
		{
			Dictionary<string, ListVariableRuntime> dictionary = new Dictionary<string, ListVariableRuntime>();
			foreach (KeyValuePair<IdString, ListVariableRuntime> value in Values)
			{
				if (includeNonSavable)
				{
					dictionary[value.Key.String] = value.Value;
					continue;
				}
				GlobalListVariables listVariablesAsset = TRepository<VariablesRepository>.Get.Variables.GetListVariablesAsset(value.Key);
				if (!(listVariablesAsset == null) && listVariablesAsset.Save)
				{
					dictionary[value.Key.String] = value.Value;
				}
			}
			return new SaveGroupListVariables(dictionary);
		}

		public Task OnLoad(object value)
		{
			if (!(value is SaveGroupListVariables saveGroupListVariables))
			{
				return Task.FromResult(result: false);
			}
			int num = saveGroupListVariables.Count();
			for (int i = 0; i < num; i++)
			{
				IdString idString = new IdString(saveGroupListVariables.GetID(i));
				GlobalListVariables listVariablesAsset = TRepository<VariablesRepository>.Get.Variables.GetListVariablesAsset(idString);
				if (!(listVariablesAsset == null) && listVariablesAsset.Save)
				{
					IndexVariable[] indexList = saveGroupListVariables.GetData(i).Variables.ToArray();
					ListVariableRuntime listVariableRuntime = new ListVariableRuntime(saveGroupListVariables.GetData(i).TypeID, indexList);
					Values[idString] = listVariableRuntime;
					listVariableRuntime.OnStartup();
				}
			}
			return Task.FromResult(result: true);
		}
	}
}
