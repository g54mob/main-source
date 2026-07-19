using System;
using System.Collections.Generic;
using System.Linq;
using UniGLTF;
using UnityEngine;

namespace VRM
{
	public static class glTF_VRMExtensions
	{
		[Obsolete("Use Create(root, meshes, binding)")]
		public static glTF_VRM_BlendShapeBind Cerate(Transform root, BlendShapeBinding binding, gltfExporter exporter)
		{
			return Create(root, binding, exporter);
		}

		public static glTF_VRM_BlendShapeBind Create(Transform root, BlendShapeBinding binding, gltfExporter exporter)
		{
			SkinnedMeshRenderer component = root.transform.GetFromPath(binding.RelativePath).GetComponent<SkinnedMeshRenderer>();
			if (component == null)
			{
				return null;
			}
			if (!component.gameObject.activeInHierarchy)
			{
				return null;
			}
			Mesh sharedMesh = component.sharedMesh;
			int num = exporter.Meshes.IndexOf(sharedMesh);
			if (num == -1)
			{
				return null;
			}
			if (!exporter.MeshBlendShapeIndexMap.TryGetValue(sharedMesh, out var value))
			{
				return null;
			}
			if (!value.TryGetValue(binding.Index, out var value2))
			{
				return null;
			}
			return new glTF_VRM_BlendShapeBind
			{
				mesh = num,
				index = value2,
				weight = binding.Weight
			};
		}

		public static void Add(this glTF_VRM_BlendShapeMaster master, BlendShapeClip clip, gltfExporter exporter)
		{
			List<glTF_VRM_BlendShapeBind> list = new List<glTF_VRM_BlendShapeBind>();
			if (clip.Values != null)
			{
				BlendShapeBinding[] values = clip.Values;
				foreach (BlendShapeBinding binding in values)
				{
					glTF_VRM_BlendShapeBind glTF_VRM_BlendShapeBind2 = Create(exporter.Copy.transform, binding, exporter);
					if (glTF_VRM_BlendShapeBind2 != null)
					{
						list.Add(glTF_VRM_BlendShapeBind2);
					}
				}
			}
			List<glTF_VRM_MaterialValueBind> list2 = new List<glTF_VRM_MaterialValueBind>();
			if (clip.MaterialValues != null)
			{
				list2.AddRange(clip.MaterialValues.Select((MaterialValueBinding y) => new glTF_VRM_MaterialValueBind
				{
					materialName = y.MaterialName,
					propertyName = y.ValueName,
					targetValue = y.TargetValue.ToArray()
				}));
			}
			glTF_VRM_BlendShapeGroup item = new glTF_VRM_BlendShapeGroup
			{
				name = clip.BlendShapeName,
				presetName = clip.Preset.ToString().ToLower(),
				isBinary = clip.IsBinary,
				binds = list,
				materialValues = list2
			};
			master.blendShapeGroups.Add(item);
		}

		public static void Apply(this glTF_VRM_DegreeMap map, CurveMapper mapper)
		{
			map.curve = mapper.Curve.keys.SelectMany((Keyframe x) => new float[4] { x.time, x.value, x.inTangent, x.outTangent }).ToArray();
			map.xRange = mapper.CurveXRangeDegree;
			map.yRange = mapper.CurveYRangeDegree;
		}
	}
}
