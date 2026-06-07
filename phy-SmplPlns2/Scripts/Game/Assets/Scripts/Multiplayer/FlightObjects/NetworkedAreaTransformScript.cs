using FishNet.Serializing;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.FlightObjects
{
	public class NetworkedAreaTransformScript : NetworkedAreaItemScript
	{
		[SerializeField]
		private float _deltaWeightPosition = 1f;

		[SerializeField]
		private float _deltaWeightRotation = 1f;

		private Vector3 _positionAtLastWrite;

		private Quaternion _rotationAtLastWrite;

		public override float CalculateDelta()
		{
			float num = 0f;
			if (_deltaWeightRotation > 0f)
			{
				float num2 = Quaternion.Angle(_rotationAtLastWrite, base.transform.localRotation);
				num += num2 * num2 * _deltaWeightRotation;
			}
			if (_deltaWeightPosition > 0f)
			{
				num += (_positionAtLastWrite - base.transform.localPosition).sqrMagnitude * _deltaWeightPosition;
			}
			return num * base.TimeSinceLastWrite;
		}

		public override void ReadState(PooledReader reader, float timeDelta)
		{
			base.ReadState(reader, timeDelta);
			if (_deltaWeightPosition > 0f)
			{
				base.transform.localPosition = reader.ReadVector3();
			}
			if (_deltaWeightRotation > 0f)
			{
				base.transform.localRotation = Quaternion.Euler(reader.ReadVector3());
			}
		}

		public override void WriteState(PooledWriter writer)
		{
			base.WriteState(writer);
			if (_deltaWeightPosition > 0f)
			{
				_positionAtLastWrite = base.transform.localPosition;
				writer.WriteVector3(_positionAtLastWrite);
			}
			if (_deltaWeightRotation > 0f)
			{
				_rotationAtLastWrite = base.transform.localRotation;
				writer.WriteVector3(base.transform.localRotation.eulerAngles);
			}
		}
	}
}
