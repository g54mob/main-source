using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Character.FacialExpression
{
	public class BlendShapeRecorderScript : MonoBehaviour
	{
		[Serializable]
		public class BlendShapeData
		{
			[SerializeField]
			private string _blendName;

			[SerializeField]
			[Range(0f, 100f)]
			private int _defaultWeight;

			[SerializeField]
			private int _index;

			[SerializeField]
			[Range(0f, 100f)]
			private int _weight;

			public int DefaultWeight => _weight;

			public int Index => _index;

			public string Name => _blendName;

			public int Weight => _weight;

			public BlendShapeData(int index, string name, int defaultWeight)
			{
				_index = index;
				_blendName = name;
				_defaultWeight = defaultWeight;
				_weight = defaultWeight;
			}
		}

		private List<BlendShapeData> _blendShapes;

		private Mesh _faceMesh;

		[SerializeField]
		private SkinnedMeshRenderer _faceRenderer;

		[ContextMenu("Generate Shapes Enum")]
		protected void GenerateShapesEnum()
		{
			PopulateBlendShapes();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("public enum FaceShape");
			stringBuilder.AppendLine("{");
			foreach (BlendShapeData blendShape in _blendShapes)
			{
				stringBuilder.Append("    ");
				stringBuilder.Append(blendShape.Name.Replace(".", string.Empty).Replace("_", string.Empty).Replace("face", string.Empty)
					.Replace("bs", string.Empty));
				stringBuilder.Append(" = ");
				stringBuilder.Append(blendShape.Index);
				stringBuilder.AppendLine(",");
			}
			stringBuilder.AppendLine("}");
			Debug.Log(stringBuilder.ToString());
		}

		protected void PopulateBlendShapes()
		{
			if (_faceRenderer == null)
			{
				_faceRenderer = GetComponent<SkinnedMeshRenderer>();
			}
			_faceMesh = _faceRenderer.sharedMesh;
			_blendShapes = new List<BlendShapeData>();
			for (int i = 0; i < _faceMesh.blendShapeCount; i++)
			{
				string blendShapeName = _faceMesh.GetBlendShapeName(i);
				int defaultWeight = Mathf.RoundToInt(_faceRenderer.GetBlendShapeWeight(i));
				_blendShapes.Add(new BlendShapeData(i, blendShapeName, defaultWeight));
			}
		}
	}
}
