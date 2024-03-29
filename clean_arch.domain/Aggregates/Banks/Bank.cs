﻿using clean_arch.common.Domain.Seedwork;
using clean_arch.common.Domain.Seedwork.Interfaces;
using clean_arch.domain.Aggregates.Customers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace clean_arch.domain.Aggregates.Banks
{
    public class Bank : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }

        private List<Customer> _customers;
        public IReadOnlyCollection<Customer> Customers => _customers.AsReadOnly();


        public Bank(string name)
        {
            Name = name;
            _customers = new();
        }

        #region Behaviors / Methods

        public void AddUser(Customer customer)
        {
            _customers.Add(customer);
        }

        public void RemoveUser(Guid id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);
            _customers.Remove(customer);
        }

        #endregion

    }
}
