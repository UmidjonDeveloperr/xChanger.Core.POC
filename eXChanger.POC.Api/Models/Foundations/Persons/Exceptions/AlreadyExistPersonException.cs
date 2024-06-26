﻿using System;
using Xeptions;

namespace eXChanger.POC.Models.Foundations.Persons.Exceptions
{
	public class AlreadyExistPersonException : Xeption
	{
		public AlreadyExistPersonException(Exception innerException)
			: base(message: "Person is already exist. Please try again",
				  innerException)
		{ }
	}
}
