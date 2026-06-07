using System.Collections.Generic;
using UnityEngine;

public class TransactionsDataBases : MonoBehaviour
{
	public static TransactionsDataBases instance;

	[SerializeField]
	public List<Transaction> transactionList;

	private void Awake()
	{
	}

	public void AddTransaction(string title, string type_transaction, int type, bool isPlus, float currency)
	{
	}

	public string GeneratedTransactionNumber()
	{
		return null;
	}

	public List<Transaction> GetTransactionsReversed()
	{
		return null;
	}

	public string TransactionListToJson()
	{
		return null;
	}

	public void JsonToTansactionList(string json)
	{
	}
}
