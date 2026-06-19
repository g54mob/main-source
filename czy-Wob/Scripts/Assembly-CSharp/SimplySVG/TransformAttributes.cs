using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SimplySVG
{
	public class TransformAttributes
	{
		private enum TransformCommand
		{
			none = 0,
			matrix = 1,
			translate = 2,
			rotate = 3,
			scale = 4,
			skewx = 5,
			skewy = 6
		}

		private List<Matrix> transforms;

		private Matrix _combinedTransform;

		public Matrix combinedTransform
		{
			get
			{
				if (_combinedTransform == null)
				{
					_combinedTransform = Matrix.IdentityMatrix(3, 3);
					foreach (Matrix transform in transforms)
					{
						_combinedTransform *= transform;
					}
				}
				return _combinedTransform;
			}
			private set
			{
				_combinedTransform = value;
			}
		}

		public TransformAttributes()
		{
			transforms = new List<Matrix>();
		}

		public void Gather(TransformAttributes other)
		{
			combinedTransform *= other.combinedTransform;
			if (other.transforms.Count > 0)
			{
				transforms.AddRange(other.transforms);
			}
		}

		public bool AddAttribute(string attributeName, string attributeValue)
		{
			bool flag = true;
			switch (attributeName)
			{
			case "transform":
				flag = ParseTransform(attributeValue, ref transforms);
				break;
			case "x":
			{
				flag = float.TryParse(attributeValue, out var result2);
				if (flag)
				{
					transforms.Add(MatrixUtils.Translate(result2));
				}
				break;
			}
			case "y":
			{
				flag = float.TryParse(attributeValue, out var result);
				if (flag)
				{
					transforms.Add(MatrixUtils.Translate(0f, result));
				}
				break;
			}
			default:
				return false;
			}
			if (!flag)
			{
				throw new Exception("Failed to parse Transformation Attribute " + attributeName + " with value " + attributeValue);
			}
			return true;
		}

		public static TransformAttributes CreateDefault()
		{
			return new TransformAttributes();
		}

		private static bool ParseTransform(string data, ref List<Matrix> parsedMatrices)
		{
			data = data.ToLower();
			foreach (Match item2 in new Regex("([a-z]+\\()([\\-\\+\\de,+.\\s]*)(\\))", RegexOptions.IgnoreCase).Matches(data))
			{
				string value = new Regex("([a-z]+)(?=\\()", RegexOptions.IgnoreCase).Match(item2.Value).Value;
				if (value == null)
				{
					return false;
				}
				TransformCommand transformCommand;
				try
				{
					transformCommand = (TransformCommand)Enum.Parse(typeof(TransformCommand), value);
				}
				catch (Exception)
				{
					transformCommand = TransformCommand.none;
				}
				if (transformCommand == TransformCommand.none)
				{
					return false;
				}
				int num = item2.Value.IndexOf('(') + 1;
				int num2 = item2.Value.IndexOf(')', num) - 1;
				string input = item2.Value.Substring(num, num2 - num + 1);
				Regex regex = new Regex("(?=\\s*)([\\+\\-]?\\d+(\\.\\d+)?(e[\\+\\-]?\\d+)?)((?=(\\s*[, ]\\s*))|(\\s*$))", RegexOptions.IgnoreCase);
				List<float> list = new List<float>(6);
				foreach (Match item3 in regex.Matches(input))
				{
					if (!ImportUtilities.ParseFloat(item3.Value, out var f))
					{
						return false;
					}
					list.Add(f);
				}
				if (list.Count < 1)
				{
					return false;
				}
				Matrix item = Matrix.IdentityMatrix(3, 3);
				switch (transformCommand)
				{
				case TransformCommand.matrix:
					if (list.Count != 6)
					{
						return false;
					}
					item = MatrixUtils.Transform(list[0], list[1], list[2], list[3], list[4], list[5]);
					break;
				case TransformCommand.translate:
					if (list.Count > 2)
					{
						return false;
					}
					item = ((list.Count != 2) ? MatrixUtils.Translate(list[0]) : MatrixUtils.Translate(list[0], list[1]));
					break;
				case TransformCommand.rotate:
				{
					if (list.Count > 3 || (list.Count > 1 && list.Count < 3))
					{
						return false;
					}
					float a = list[0] / 180f * (float)Math.PI;
					item = ((list.Count != 3) ? MatrixUtils.Rotate(a) : (MatrixUtils.Translate(0f - list[1], 0f - list[2]) * MatrixUtils.Rotate(a) * MatrixUtils.Translate(list[1], list[2])));
					break;
				}
				case TransformCommand.scale:
					if (list.Count > 2)
					{
						return false;
					}
					item = MatrixUtils.Scale(list[0], (list.Count == 2) ? list[1] : list[0]);
					break;
				case TransformCommand.skewx:
					item = MatrixUtils.SkewX(list[0] / 180f * (float)Math.PI);
					break;
				case TransformCommand.skewy:
					item = MatrixUtils.SkewY(list[0] / 180f * (float)Math.PI);
					break;
				}
				parsedMatrices.Add(item);
			}
			return true;
		}
	}
}
