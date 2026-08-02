using System.Collections.Generic;
using FIMSpace.FGenerating;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class RAF_FadeOnPlayedAnimation : RagdollAnimatorFeatureBase
	{
		private enum ELayerSelectMode
		{
			ByIndex = 0,
			Auto = 1
		}

		private FUniversalVariable _fadeSpeedV;

		private FUniversalVariable _layerV;

		private float fadeValue = 1f;

		private float sd_eneMul;

		private List<int> stateHashes;

		private List<int> tagHashes;

		private FUniversalVariable _layerMode;

		private FUniversalVariable _layerSkip;

		private List<int> layersToCheck;

		private int lastAutoWeightIndex;

		private bool InitLayerCheck(RagdollAnimatorFeatureHelper helper)
		{
			if (helper.ParentRagdollHandler.Mecanim == null)
			{
				return false;
			}
			if (_layerMode.GetInt() == 0)
			{
				return false;
			}
			if (_layerMode == null || _layerSkip == null)
			{
				return false;
			}
			layersToCheck = new List<int>();
			string[] array = _layerSkip.GetString().Split(',');
			for (int i = 0; i < helper.ParentRagdollHandler.Mecanim.layerCount; i++)
			{
				layersToCheck.Add(i);
			}
			for (int j = 0; j < array.Length; j++)
			{
				if (int.TryParse(array[j], out var result))
				{
					layersToCheck.Remove(result);
					continue;
				}
				int num = -1;
				for (int k = 0; k < helper.ParentRagdollHandler.Mecanim.layerCount; k++)
				{
					if (helper.ParentRagdollHandler.Mecanim.GetLayerName(k) == array[j])
					{
						num = k;
						break;
					}
				}
				if (num != -1)
				{
					layersToCheck.Remove(num);
				}
			}
			return true;
		}

		public override bool OnInit()
		{
			if (base.ParentRagdollHandler.Mecanim == null)
			{
				Debug.Log("[Legs Animator] Fade On Animation Module: Not found animator reference in legs animator Extra/Control!");
				base.Helper.Enabled = false;
				return false;
			}
			_layerV = base.Helper.RequestVariable("Animation Layer", 0);
			_fadeSpeedV = base.Helper.RequestVariable("Fade Speed", 0.75f);
			FUniversalVariable fUniversalVariable = base.Helper.RequestVariable("Animation State Tag", "");
			string[] array = base.Helper.RequestVariable("Animation State Name", "").GetString().Split(',');
			if (array.Length != 0)
			{
				stateHashes = new List<int>();
				for (int i = 0; i < array.Length; i++)
				{
					if (!string.IsNullOrWhiteSpace(array[i]))
					{
						stateHashes.Add(Animator.StringToHash(array[i]));
					}
				}
			}
			string[] array2 = fUniversalVariable.GetString().Split(',');
			if (array2.Length != 0)
			{
				tagHashes = new List<int>();
				for (int j = 0; j < array2.Length; j++)
				{
					if (!string.IsNullOrWhiteSpace(array2[j]))
					{
						tagHashes.Add(Animator.StringToHash(array2[j]));
					}
				}
			}
			if (stateHashes.Count == 0 && tagHashes.Count == 0)
			{
				base.Helper.Enabled = false;
				Debug.Log("[Ragdoll Animator] Fade On Played Animation: No assigned animation state names/tags to control feature on!");
				return false;
			}
			if (_layerV.GetInt() < 0)
			{
				_layerV.SetValue(0);
			}
			if (_layerV.GetInt() > base.ParentRagdollHandler.Mecanim.layerCount - 1)
			{
				_layerV.SetValue(base.ParentRagdollHandler.Mecanim.layerCount - 1);
			}
			_layerMode = base.Helper.RequestVariable("Mode", 0);
			_layerSkip = base.Helper.RequestVariable("Skip", "");
			if (_layerMode.GetInt() == 1 && !InitLayerCheck(base.Helper))
			{
				_layerMode.SetValue(0);
			}
			base.ParentRagdollHandler.AddToUpdateLoop(UpdateFeature);
			return base.OnInit();
		}

		public override void OnDestroyFeature()
		{
			base.ParentRagdollHandler.RemoveFromUpdateLoop(UpdateFeature);
			base.OnDestroyFeature();
		}

		private void UpdateFeature()
		{
			if (!base.Helper.Enabled)
			{
				return;
			}
			Animator mecanim = base.ParentRagdollHandler.Mecanim;
			if (mecanim == null)
			{
				return;
			}
			int layerIndex = _layerV.GetInt();
			if (_layerMode.GetInt() == 1)
			{
				float num = 0f;
				int num2 = -1;
				for (int num3 = layersToCheck.Count - 1; num3 >= 0; num3--)
				{
					int num4 = layersToCheck[num3];
					float layerWeight = mecanim.GetLayerWeight(num4);
					if (layerWeight > 0.95f)
					{
						num2 = num4;
						break;
					}
					if (layerWeight > num)
					{
						num = layerWeight;
						num2 = num4;
					}
				}
				layerIndex = (lastAutoWeightIndex = num2);
			}
			AnimatorStateInfo animatorStateInfo = (mecanim.IsInTransition(layerIndex) ? mecanim.GetNextAnimatorStateInfo(layerIndex) : mecanim.GetCurrentAnimatorStateInfo(layerIndex));
			bool flag = false;
			for (int i = 0; i < stateHashes.Count; i++)
			{
				if (animatorStateInfo.shortNameHash == stateHashes[i])
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				for (int j = 0; j < tagHashes.Count; j++)
				{
					if (animatorStateInfo.tagHash == tagHashes[j])
					{
						flag = true;
						break;
					}
				}
			}
			float num5 = 0.3f - _fadeSpeedV.GetFloat() * 0.299f;
			if (flag)
			{
				fadeValue = Mathf.SmoothDamp(fadeValue, -0.001f, ref sd_eneMul, num5 * 0.9f, 100000f, base.ParentRagdollHandler.Delta);
			}
			else
			{
				fadeValue = Mathf.SmoothDamp(fadeValue, 1.01f, ref sd_eneMul, num5, 100000f, base.ParentRagdollHandler.Delta);
			}
			fadeValue = Mathf.Clamp01(fadeValue);
			ApplyBlends();
		}

		public virtual void ApplyBlends()
		{
			base.ParentRagdollHandler.RagdollBlend = Mathf.Max(0.0001f, fadeValue);
		}
	}
}
