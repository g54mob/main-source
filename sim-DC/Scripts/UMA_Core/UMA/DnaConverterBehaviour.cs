using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace UMA
{
	public class DnaConverterBehaviour : MonoBehaviour, IDNAConverter
	{
		[SerializeField]
		[FormerlySerializedAs("DNAType")]
		protected Type _dnaType;

		[SerializeField]
		[FormerlySerializedAs("DisplayValue")]
		protected string _displayValue;

		[SerializeField]
		protected int dnaTypeHash;

		[FormerlySerializedAs("PreApplyDnaAction")]
		protected DNAConvertDelegate _preApplyDnaAction;

		protected DNAConvertDelegate _applyDnaAction;

		protected DNAConvertDelegate _postApplyDnaAction;

		public Type DNAType
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string DisplayValue
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual int DNATypeHash
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public DNAConvertDelegate PreApplyDnaAction
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DNAConvertDelegate PostApplyDnaAction
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DNAConvertDelegate ApplyDnaAction
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		string IDNAConverter.name => null;

		public virtual void Prepare()
		{
		}
	}
}
