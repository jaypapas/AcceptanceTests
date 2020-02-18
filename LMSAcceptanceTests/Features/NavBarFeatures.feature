Feature: NavBarFeatures
	In order to browse different pages on LMS website
	As a user
	I want to be able to use the navigation bar

Scenario Outline: LMS navigation bar
	Given I am on LMS homepage
	When I click on any navigation bar <link>
	Then I should be taken to the selected navigation bar <linkPage>

	Examples:
		| link        | linkPage    |
		| About Us    | about-us    |
		| Lenders     | lenders     |
		| Customers   | customers   |
		| Law Firms   | law-firms   |
		| Brokers     | brokers     |
		| News        | news        |
		| Contact Us  | contact-us  |
		| Recruitment | recruitment |