using System;
using System.Collections.Generic;
using NSEipix.Base;
using UnityEngine;

namespace NSEipix.Repository
{
	[Serializable]
	public class RepositoryDto<M> where M : NSEipix.Base.Model
	{
		[SerializeField]
		private List<M> repository = new List<M>();

		public List<M> Repository
		{
			get
			{
				return repository;
			}
			set
			{
				repository = value;
			}
		}

		public RepositoryDto()
		{
		}

		public RepositoryDto(List<M> repository)
		{
			this.repository = repository;
		}
	}
}
