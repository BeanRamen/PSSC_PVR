﻿namespace lab2.exemple.Exceptions
{
    public class InvalidStudentRegistrationNumberException : Exception
    {
        public InvalidStudentRegistrationNumberException()
        {
        }

        public InvalidStudentRegistrationNumberException(string? message) : base(message)
        {
        }

        public InvalidStudentRegistrationNumberException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}