﻿using System;
namespace ProjectFall2020
{
    class CustomerManager
    {
        private static int currentCustNumber;
        private int maxNumCustomers;
        private int numCustomers;
        private Customer[] customerList;

        public CustomerManager(int ccn, int max)
        {
            currentCustNumber = ccn;
            maxNumCustomers = max;
            numCustomers = 0;
            customerList = new Customer[maxNumCustomers];
        }

        public bool addCustomer(string fn, string ln, string ph)
        {
            if (numCustomers >= maxNumCustomers) { return false; }
            Customer c = new Customer(currentCustNumber, fn, ln, ph);
            currentCustNumber++;
            customerList[numCustomers] = c;
            numCustomers++;
            return true;
        }

        public int findCustomer(int cid)
        {
            for (int x = 0; x < numCustomers; x++)
            {
                if (customerList[x].getId() == cid)
                    return x;
            }
            return -1;
        }

        public bool customerExist(int cid)
        {
            int loc = findCustomer(cid);
            if (loc == -1) { return false; }
            return true;
        }

        public Customer getCustomer(int cid)
        {
            int loc = findCustomer(cid);
            if (loc == -1) { return null; }
            return customerList[loc];
        }

        public string getCustomerInfo(int cid)
        {
            int loc = findCustomer(cid);
            if (loc == -1) { return "There is no customer with id " + cid + "."; }
            return customerList[loc].ToString();
        }

        public bool deleteCustomer(int cid)
        {
            int loc = findCustomer(cid);
            if (loc == -1) { return false; }
            customerList[loc] = customerList[numCustomers - 1];
            numCustomers--;
            return true;
        }

        public string getCustomerList()
        {
            string s = "Customer List:";
            s = s + "\nNumber \t Name \t  \t Phone";
            for (int x = 0; x < numCustomers; x++)
            {
                s = s + "\n" + customerList[x].getId() + "\t" + customerList[x].getFirstName() + "\t" + customerList[x].getLastName() + "\t" + customerList[x].getPhone();
            }
            return s;
        }


    }

}
