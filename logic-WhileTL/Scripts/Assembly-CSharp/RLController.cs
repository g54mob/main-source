using UnityEngine;

public class RLController : MonoBehaviour
{
	private Agent a;

	private int epoch;

	private double[] inputs = new double[2];

	private void Start()
	{
		Random.InitState(1234);
		a = new Agent(2, 2, 0);
		epoch = 0;
	}

	private void Update()
	{
		string text = "EPOCH : " + epoch;
		for (int i = 0; i <= 1; i++)
		{
			for (int j = 0; j <= 1; j++)
			{
				inputs[0] = i;
				inputs[1] = j;
				int num = a.fit(inputs);
				text = text + " " + num;
				if (num == (i + j) % 2)
				{
					a.reward(0.95);
				}
				else
				{
					a.reward(-0.01);
				}
			}
		}
		Debug.Log(text);
		epoch++;
	}
}
