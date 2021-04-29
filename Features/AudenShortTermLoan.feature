Feature: AudenShortTermLoan
	

Background: 
Given I have navigated to 'https://www.auden.co.uk/Credit/ShortTermLoan'

Scenario: Slider Amount is Loan amount
	When I select loan amount
	Then Slider amount is the same as loan amount

Scenario: Min and Max slider amount
Then The min loan amount is £200
And The max loan amount is £500

Scenario: Repayment date
When I select a payment date
Then the first repayment date will default to friday if repayment date falls on weekend

	