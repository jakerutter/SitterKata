# SitterKata

## TDD sitter kata written in .Net Core 3.1 using C# and XUnit for testing

### Assumptions
I made the assumption that bed time will be no later than midnight

Background
----------
This kata simulates a babysitter working and getting paid for one night.  The rules are pretty straight forward:

The babysitter 
- starts no earlier than 5:00PM
- leaves no later than 4:00AM
- gets paid $12/hour from start-time to bedtime
- gets paid $8/hour from bedtime to midnight
- gets paid $16/hour from midnight to end of job
- gets paid for full hours (no fractional hours)


Feature:
As a babysitter
In order to get paid for 1 night of work
I want to calculate my nightly charge

