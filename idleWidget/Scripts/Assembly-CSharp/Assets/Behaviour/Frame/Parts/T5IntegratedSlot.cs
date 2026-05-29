using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T5IntegratedSlot : MonoBehaviour
	{
		[SerializeField]
		private LineRenderer _lineGreen;

		[SerializeField]
		private LineRenderer _lineRed;

		[SerializeField]
		private Vector2 _inputGreen;

		[SerializeField]
		private Vector2 _inputRed;

		[SerializeField]
		private Vector2[] _outputs;

		public int ExitGreen { get; private set; }

		public int ExitRed { get; private set; }

		public void SetLines(int exitGreen, int exitRed, bool show)
		{
			ExitGreen = exitGreen;
			ExitRed = exitRed;
			_setupLine(_lineGreen, _inputGreen, _outputs[exitGreen]);
			_setupLine(_lineRed, _inputRed, _outputs[exitRed]);
			if (show)
			{
				_lineGreen.gameObject.SetActive(value: true);
				_lineRed.gameObject.SetActive(value: true);
			}
		}

		public void SetLineZ(float z)
		{
			_lineGreen.transform.localPosition = new Vector3(0f, 0f, z);
			_lineRed.transform.localPosition = new Vector3(0f, 0f, z);
		}

		private void _setupLine(LineRenderer line, Vector2 from, Vector2 to)
		{
			if (from.y == to.y)
			{
				line.positionCount = 2;
				line.SetPositions(new Vector3[2] { from, to });
			}
			else if (Mathf.Abs(to.y) > 0.5f)
			{
				line.positionCount = 3;
				line.SetPositions(new Vector3[3]
				{
					from,
					new Vector2(to.x, from.y),
					to
				});
			}
			else
			{
				line.positionCount = 4;
				line.SetPositions(new Vector3[4]
				{
					from,
					new Vector2(-0.2f, from.y),
					new Vector2(0.2f, to.y),
					to
				});
			}
		}

		public void SetupPuzzle(bool show)
		{
			int num = SeededRandom.Global.RandomRange(0, _outputs.Length);
			int num2;
			do
			{
				num2 = SeededRandom.Global.RandomRange(0, _outputs.Length);
			}
			while (num2 == num);
			SetLines(num, num2, show);
		}

		public void Clear()
		{
			_lineGreen.gameObject.SetActive(value: false);
			_lineRed.gameObject.SetActive(value: false);
		}
	}
}
