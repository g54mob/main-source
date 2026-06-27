using System.Collections.Generic;
using System.ComponentModel;

namespace Rewired.Utils.Classes.Data
{
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class InspectorValue<T>
	{
		private T PqqgUEqQGwCtOpAZXIfuznybsQZQ;

		private bool toxJSOlpArBqPqbWjqopGKTtDyJDA;

		public bool isSet => toxJSOlpArBqPqbWjqopGKTtDyJDA;

		public T value
		{
			get
			{
				return PqqgUEqQGwCtOpAZXIfuznybsQZQ;
			}
			set
			{
				PqqgUEqQGwCtOpAZXIfuznybsQZQ = value;
				toxJSOlpArBqPqbWjqopGKTtDyJDA = true;
			}
		}

		public bool SetIfChanged(T value)
		{
			if (!toxJSOlpArBqPqbWjqopGKTtDyJDA)
			{
				this.value = value;
				return false;
			}
			if (!EqualityComparer<T>.Default.Equals(PqqgUEqQGwCtOpAZXIfuznybsQZQ, value))
			{
				this.value = value;
				return true;
			}
			return false;
		}

		public void Clear()
		{
			toxJSOlpArBqPqbWjqopGKTtDyJDA = false;
			PqqgUEqQGwCtOpAZXIfuznybsQZQ = default(T);
		}
	}
}
