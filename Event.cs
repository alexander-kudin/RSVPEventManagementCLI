﻿using System;
using System.Linq;

namespace ProjectFall2020
{
    class Event
    {
        private int eventId;
        private string eventName;
        private string venue;
        private Date eventDate;
        private int maxAttendees;
        private int numAttendees;
        private Customer[] attendeeList;

        public Event(int eventId, string name, string venue, Date eventDate, int maxAttendees)
        {
            this.eventId = eventId;
            this.eventName = name;
            this.venue = venue;
            this.eventDate = eventDate;
            this.maxAttendees = maxAttendees;
            numAttendees = 0;
            attendeeList = new Customer[maxAttendees];
        }

        public int getEventId() { return eventId; }
        public string getEventName() { return eventName; }
        public string getVenue() { return venue; }

        public int getMaxAttendees() { return maxAttendees; }
        public int getNumAttendees() { return numAttendees; }

        public bool addAttendee(Customer c)
        {
            if (numAttendees >= maxAttendees) { return false; }
            attendeeList[numAttendees] = c;
            numAttendees++;
            return true;
        }

        private int findAttendee(int custId)
        {
            for (int x = 0; x < numAttendees; x++)
            {
                if (attendeeList[x].getId() == custId)
                    return x;
            }
            return -1;
        }

        public bool removeAttendee(int custId)
        {
            int loc = findAttendee(custId);
            if (loc == -1) return false;
            attendeeList[loc] = attendeeList[numAttendees - 1];
            numAttendees--;
            return true;
        }

        public string getAttendees()
        {
            string s = "\nCustomers registered :";
            for (int x = 0; x < numAttendees; x++)
            {
                s = s + "\n" + attendeeList[x].getFirstName() + " " + attendeeList[x].getLastName();
            }
            return s;
        }

        public override string ToString()
        {
            string s = "Event: " + eventId + "\nName: " + eventName;
            s = s + "\nVenue: " + venue;
            s = s + "\nDate:" + eventDate;
            s = s + "\nRegistered Attendees:" + numAttendees;
            s = s + "\nAvailable spaces:" + (maxAttendees - numAttendees);
            s = s + getAttendees();
            return s;
        }

        // MODIFICATION (OLEKSII PEDKO) – IMPLEMENTED METHODS: isAlreadyRegistered().

        public bool isAlreadyRegistered(int cid)
        {
            if (numAttendees == 0) { return false; }
            if (findAttendee(cid) == -1) { return false; }
            return true;
        }

    }


}
