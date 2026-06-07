using DV.Utils;
using UnityEngine;

namespace DV.VFX
{
	public class TrainVegetationInteractionManager : SingletonBehaviour<TrainVegetationInteractionManager>
	{
		private const string TRAIN_CAR_INVERSE_MATRIX = "_TrainCarInverseMatrix";

		private const string TRAIN_CAR_MATRIX_KEYWORD = "TRAIN_CAR_MATRIX";

		private readonly int TRAIN_CAR_INVERSE_MATRIX_ID = Shader.PropertyToID("_TrainCarInverseMatrix");

		private Matrix4x4 boundsMatrix;

		public new static string AllowAutoCreate()
		{
			return "[TrainVegetationInteractionManager]";
		}

		private void Start()
		{
			PlayerManager.CarChanged += OnCarChanged;
			if ((bool)PlayerManager.Car)
			{
				OnCarChanged(PlayerManager.Car);
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			PlayerManager.CarChanged -= OnCarChanged;
		}

		private void OnCarChanged(TrainCar car)
		{
			if ((bool)car)
			{
				if (!Shader.IsKeywordEnabled("TRAIN_CAR_MATRIX"))
				{
					Shader.EnableKeyword("TRAIN_CAR_MATRIX");
				}
				Bounds bounds = car.Bounds;
				boundsMatrix = Matrix4x4.TRS(bounds.center, Quaternion.identity, bounds.size).inverse;
			}
			else if (Shader.IsKeywordEnabled("TRAIN_CAR_MATRIX"))
			{
				Shader.DisableKeyword("TRAIN_CAR_MATRIX");
			}
		}

		private void LateUpdate()
		{
			if ((bool)PlayerManager.Car)
			{
				Matrix4x4 worldToLocalMatrix = PlayerManager.Car.transform.worldToLocalMatrix;
				worldToLocalMatrix = boundsMatrix * worldToLocalMatrix;
				Shader.SetGlobalMatrix(TRAIN_CAR_INVERSE_MATRIX_ID, worldToLocalMatrix);
			}
		}
	}
}
