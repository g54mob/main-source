using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/Utilities/Mesh/Blend Shapes")]
	public class BlendShape : MonoBehaviour
	{
		[CreateScriptableAsset]
		public BlendShapePreset preset;

		[RequiredField]
		public SkinnedMeshRenderer mesh;

		public SkinnedMeshRenderer[] LODs;

		public float[] blendShapes;

		[Tooltip("Min Value to use on the blendshapes")]
		public float Min = -100f;

		[Tooltip("Max Value to use on the blendshapes")]
		public float Max = 100f;

		[Tooltip("Start with a random shape on Start")]
		public bool random;

		public int PinnedShape;

		internal bool HasBlendShapes
		{
			get
			{
				if ((bool)mesh)
				{
					return mesh.sharedMesh.blendShapeCount > 0;
				}
				return false;
			}
		}

		private void Start()
		{
			if ((bool)preset)
			{
				LoadPreset();
			}
			else if (random)
			{
				Randomize();
			}
		}

		private void Reset()
		{
			mesh = GetComponentInChildren<SkinnedMeshRenderer>();
			if ((bool)mesh)
			{
				blendShapes = new float[mesh.sharedMesh.blendShapeCount];
				for (int i = 0; i < blendShapes.Length; i++)
				{
					blendShapes[i] = mesh.GetBlendShapeWeight(i);
				}
			}
		}

		public virtual float[] GetBlendShapeValues()
		{
			if (HasBlendShapes)
			{
				float[] array = new float[mesh.sharedMesh.blendShapeCount];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = mesh.GetBlendShapeWeight(i);
				}
				return array;
			}
			return null;
		}

		public void SmoothBlendShape(BlendShapePreset preset)
		{
			LoadSmoothPreset(preset);
		}

		public void LoadSmoothPreset(BlendShapePreset preset)
		{
			StopAllCoroutines();
			preset.SmoothBlend(mesh);
			SkinnedMeshRenderer[] lODs = LODs;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in lODs)
			{
				preset.SmoothBlend(skinnedMeshRenderer);
			}
		}

		public void SavePreset()
		{
			if ((bool)preset)
			{
				preset.blendShapes = new float[blendShapes.Length];
				for (int i = 0; i < preset.blendShapes.Length; i++)
				{
					preset.blendShapes[i] = blendShapes[i];
				}
				Debug.Log("Preset: " + preset.name + " Saved");
				MTools.SetDirty(preset);
			}
		}

		public void LoadPreset()
		{
			LoadPreset(preset);
		}

		public void LoadPreset(BlendShapePreset preset)
		{
			if ((bool)preset)
			{
				blendShapes = new float[preset.blendShapes.Length];
				for (int i = 0; i < preset.blendShapes.Length; i++)
				{
					blendShapes[i] = preset.blendShapes[i];
				}
				Debug.Log("Preset: " + preset.name + " Loaded", this);
				UpdateBlendShapes();
				if (!Application.isPlaying)
				{
					MTools.SetDirty(preset);
				}
			}
		}

		public virtual void SetShapesCount()
		{
			if ((bool)mesh)
			{
				blendShapes = new float[mesh.sharedMesh.blendShapeCount];
				for (int i = 0; i < blendShapes.Length; i++)
				{
					blendShapes[i] = mesh.GetBlendShapeWeight(i);
				}
			}
		}

		public virtual void Randomize()
		{
			if (HasBlendShapes)
			{
				for (int i = 0; i < blendShapes.Length; i++)
				{
					blendShapes[i] = Random.Range(Min, Max);
					mesh.SetBlendShapeWeight(i, blendShapes[i]);
				}
				UpdateLODs();
			}
		}

		public virtual void ResetToZero()
		{
			if (HasBlendShapes)
			{
				for (int i = 0; i < blendShapes.Length; i++)
				{
					blendShapes[i] = 0f;
					mesh.SetBlendShapeWeight(i, blendShapes[i]);
				}
				UpdateLODs();
			}
		}

		public virtual void SetWeight(string name, float value)
		{
			if (HasBlendShapes)
			{
				PinnedShape = mesh.sharedMesh.GetBlendShapeIndex(name);
				if (PinnedShape != -1)
				{
					mesh.SetBlendShapeWeight(PinnedShape, value);
				}
			}
		}

		public virtual void SetWeight(int index, float value)
		{
			if (HasBlendShapes)
			{
				mesh.SetBlendShapeWeight(PinnedShape = index, value);
			}
		}

		public virtual void _PinShape(string name)
		{
			PinnedShape = mesh.sharedMesh.GetBlendShapeIndex(name);
		}

		public virtual void _PinShape(int index)
		{
			PinnedShape = index;
		}

		public virtual void _PinnedShapeSetValue(float value)
		{
			if (PinnedShape != -1)
			{
				value = Mathf.Clamp(value, 0f, 100f);
				blendShapes[PinnedShape] = value;
				mesh.SetBlendShapeWeight(PinnedShape, value);
				UpdateLODs(PinnedShape);
			}
		}

		public virtual void UpdateBlendShapes()
		{
			if ((bool)mesh && blendShapes != null)
			{
				int num = Mathf.Min(mesh.sharedMesh.blendShapeCount, blendShapes.Length);
				for (int i = 0; i < num; i++)
				{
					mesh.SetBlendShapeWeight(i, blendShapes[i]);
				}
				UpdateLODs();
			}
		}

		protected virtual void UpdateLODs()
		{
			for (int i = 0; i < blendShapes.Length; i++)
			{
				UpdateLODs(i);
			}
		}

		protected virtual void UpdateLODs(int index)
		{
			if (LODs == null)
			{
				return;
			}
			SkinnedMeshRenderer[] lODs = LODs;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in lODs)
			{
				if (skinnedMeshRenderer != null && skinnedMeshRenderer.sharedMesh.blendShapeCount > index)
				{
					skinnedMeshRenderer.SetBlendShapeWeight(index, blendShapes[index]);
				}
			}
		}
	}
}
