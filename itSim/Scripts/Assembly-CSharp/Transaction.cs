using System;

[Serializable]
public class Transaction
{
	public string title;

	public string type_transaction;

	public int type;

	public bool isPlus;

	public float currency;

	public string id_transaction;

	public Transaction(string title, string type_transaction, int type, bool isPlus, float currency, string id_transaction)
	{
	}
}
