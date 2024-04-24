﻿using System.Linq;
using System.Threading.Tasks;
using eXChanger.POC.Models.Foundations.Persons;
using eXChanger.POC.Services.Foundations.Persons;

namespace eXChanger.POC.Services.Processings.Persons
{
    public class PersonProcessingService : IPersonProcessingService
    {
        private readonly IPersonService personService;

        public PersonProcessingService(IPersonService personService) =>
            this.personService = personService;

        public async ValueTask<Person> UpsertPersonAsync(Person person)
        {
            Person maybePerson = RetrievePerson(person);

            return maybePerson switch
            {
                null => await this.personService.AddPersonAsync(person),
                _ => await this.personService.UpdatePersonAsync(person)
            };
        }

        private Person RetrievePerson(Person person)
        {
            IQueryable<Person> retrievedPersons =
                this.personService.RetrieveAllPersons();

            return retrievedPersons.FirstOrDefault(storagePerson =>
                storagePerson.Id == person.Id);
        }
    }
}
