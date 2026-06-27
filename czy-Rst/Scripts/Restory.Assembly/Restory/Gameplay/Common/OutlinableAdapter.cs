using System;
using System.Linq;
using EPOOutline;
using Restory.Data.Outline;
using UnityEngine;

namespace Restory.Gameplay.Common
{
	[RequireComponent(typeof(Outlinable))]
	public class OutlinableAdapter : MonoBehaviour
	{
		[Header("General settings")]
		[SerializeField]
		private OutlineSettingsPreset preset;

		[SerializeField]
		private Outlinable outlinable;

		[SerializeField]
		private Renderer[] ignoreRenderers = Array.Empty<Renderer>();

		private OutlineSettingsPreset overridePreset;

		public OutlineSettingsPreset OverridePreset
		{
			get
			{
				return overridePreset;
			}
			set
			{
				overridePreset = value;
				ApplyPreset();
			}
		}

		public bool IsActive
		{
			get
			{
				return Outlinable.enabled;
			}
			set
			{
				ApplyPreset();
				Outlinable.enabled = value;
			}
		}

		public Outlinable Outlinable
		{
			get
			{
				if (!outlinable && !TryGetComponent<Outlinable>(out outlinable))
				{
					throw new Exception("<color=white><b>OUTLINABLE:</b></color> component Outlinable didn't set on object: <color=white>" + base.name + "</color>");
				}
				return outlinable;
			}
		}

		private void Awake()
		{
			if (!outlinable)
			{
				TryGetComponent<Outlinable>(out outlinable);
			}
			outlinable.enabled = false;
		}

		private void OnEnable()
		{
			ApplyPreset();
		}

		private void OnDestroy()
		{
			overridePreset = null;
			preset = null;
			outlinable = null;
			ignoreRenderers = Array.Empty<Renderer>();
		}

		private void ApplyPreset()
		{
			if (outlinable != null && preset != null)
			{
				((overridePreset != null) ? overridePreset : preset).Apply(outlinable);
			}
		}

		public void AddAllChildRenderersToRenderingList()
		{
			outlinable.AddAllChildRenderersToRenderingList();
			Renderer[] array = ignoreRenderers;
			foreach (Renderer ignoredRenderer in array)
			{
				OutlineTarget outlineTarget = outlinable.OutlineTargets.FirstOrDefault((OutlineTarget x) => x.Renderer == ignoredRenderer);
				if (outlineTarget != null)
				{
					outlinable.RemoveTarget(outlineTarget);
				}
			}
		}
	}
}
