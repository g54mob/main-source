using System;

public interface IStorable
{
	DateTime UtcTimestamp { get; set; }

	bool IsAuthoritative { get; set; }
}
