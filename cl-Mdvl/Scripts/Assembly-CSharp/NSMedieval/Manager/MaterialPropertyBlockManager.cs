using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Heraldry;
using NSMedieval.Utils.Pool;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class MaterialPropertyBlockManager : MonoSingleton<MaterialPropertyBlockManager>
	{
		public const string LoadedHeraldryTexturePrefix = "[loaded]";

		private const int MaxProcessItemsPerFrame = 1024;

		[NonSerialized]
		private readonly Dictionary<Renderer, MaterialPropertyBlock> blocks = new Dictionary<Renderer, MaterialPropertyBlock>();

		private void ScheduleCleanup()
		{
			MonoSingleton<TaskController>.Instance.WaitFor(1f).Then(CleanupBlocks);
		}

		public MaterialPropertyBlock GetMaterialPropertyBlock(Renderer renderer)
		{
			if (!blocks.TryGetValue(renderer, out var value))
			{
				if (renderer.HasPropertyBlock())
				{
					MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
					renderer.GetPropertyBlock(materialPropertyBlock);
					blocks.Add(renderer, materialPropertyBlock);
					return materialPropertyBlock;
				}
				MaterialPropertyBlock materialPropertyBlock2 = new MaterialPropertyBlock();
				renderer.SetPropertyBlock(materialPropertyBlock2);
				blocks.Add(renderer, materialPropertyBlock2);
				return materialPropertyBlock2;
			}
			return value;
		}

		public void RemoveFromBlocks(Transform transform)
		{
			List<Renderer> list = ListPool<Renderer>.Get();
			transform.GetComponents(list);
			if (list.Count != 0)
			{
				RemoveFromBlocks(list);
			}
			transform.GetComponentsInChildren(list);
			if (list.Count != 0)
			{
				RemoveFromBlocks(list);
			}
			ListPool<Renderer>.Return(list);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RemoveFromBlocks(List<Renderer> components)
		{
			int i = 0;
			for (int count = components.Count; i < count; i++)
			{
				Renderer key = components[i];
				blocks.Remove(key);
			}
		}

		public void CleanupBlocks()
		{
			List<Renderer> list = ListPool<Renderer>.Get();
			foreach (Renderer key in blocks.Keys)
			{
				if (key == null || key.gameObject == null || key.gameObject.transform == null)
				{
					list.Add(key);
				}
			}
			int i = 0;
			for (int count = list.Count; i < count; i++)
			{
				blocks.Remove(list[i]);
			}
			ListPool<Renderer>.Return(list);
		}

		private void OnHeraldryChanged()
		{
			CleanupBlocks();
			foreach (KeyValuePair<Renderer, MaterialPropertyBlock> block in blocks)
			{
				bool flag = false;
				MaterialPropertyBlock value = block.Value;
				Texture texture = value.GetTexture("_heraldry_crest");
				if (texture != null && !texture.name.StartsWith("[loaded]"))
				{
					value.SetTexture("_heraldry_crest", MonoSingleton<HeraldryManager>.Instance.Crest.mainTexture);
					flag = true;
				}
				texture = value.GetTexture("_heraldry_background");
				if (texture != null && !texture.name.StartsWith("[loaded]"))
				{
					value.SetTexture("_heraldry_background", MonoSingleton<HeraldryManager>.Instance.Pattern.mainTexture);
					flag = true;
				}
				if (flag)
				{
					block.Key.SetPropertyBlock(value);
				}
			}
		}

		private void Start()
		{
			MonoSingleton<HeraldryManager>.Instance.HeraldryChangedEvent += OnHeraldryChanged;
			MonoSingleton<LoadingController>.Instance.HomeSceneLoadedEvent += ScheduleCleanup;
			MonoSingleton<LoadingController>.Instance.MainSceneLoadedEvent += ScheduleCleanup;
			MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent += ScheduleCleanup;
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<HeraldryManager>.IsInstantiated())
			{
				MonoSingleton<HeraldryManager>.Instance.HeraldryChangedEvent -= OnHeraldryChanged;
			}
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.HomeSceneLoadedEvent -= ScheduleCleanup;
				MonoSingleton<LoadingController>.Instance.MainSceneLoadedEvent -= ScheduleCleanup;
				MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent -= ScheduleCleanup;
			}
			blocks.Clear();
			base.OnDestroy();
		}
	}
}
