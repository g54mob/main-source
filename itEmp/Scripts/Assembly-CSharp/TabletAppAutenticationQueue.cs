using System;

[Serializable]
public class TabletAppAutenticationQueue
{
	public int number;

	public Action actCorrect;

	public Action actIncorrect;

	public Action actCaneled;

	public bool goReceiveData;

	public float receiveDataPrograss;

	public bool receivePrograssDone;

	public bool goSendData;

	public string buttonAction;

	public float sendDataPrograss;

	public bool sendPrograssDone;
}
