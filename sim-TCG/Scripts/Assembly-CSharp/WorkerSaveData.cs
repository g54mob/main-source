using System;
using System.Collections.Generic;

[Serializable]
public class WorkerSaveData
{
	public EWorkerTask primaryTask;

	public EWorkerTask secondaryTask;

	public EWorkerTask workerTask;

	public EWorkerState currentState;

	public Vector3Serializer pos;

	public QuaternionSerializer rot;

	public bool isFillShelfWithoutLabel;

	public bool isRoundUpPrice;

	public bool isGoingHome;

	public float setPriceMultiplier;

	public List<bool> cardPackItemTypeEnabledList;
}
